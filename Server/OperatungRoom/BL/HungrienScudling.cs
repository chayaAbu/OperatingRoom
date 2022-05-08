using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class HungrienScudling
    {
        public double[,] FillMatrix(List<SurgeryDTO> listOfSurgery, List<RoomDTO> listOfRoom, List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO> S)
        {
            PreHungrien preMat = new PreHungrien();
            double[,] gradeMat = preMat.CalculateScore(listOfSurgery, listOfRoom, D, S);


            if (gradeMat == null)
                throw new ArgumentNullException(nameof(gradeMat)); //????

            var h = gradeMat.GetLength(0);
            var w = gradeMat.GetLength(1);


            //מעבר זה על המטריצה מבטיח שבכל שורה יש לפחות תא אחד שהוא אפס
            for (var i = 0; i < h; i++)
            {
                var min = int.MaxValue;

                for (var j = 0; j < w; j++)
                {
                    min = Math.Min(min, costs[i, j]);
                }

                for (var j = 0; j < w; j++)
                {
                    gradeMat[i, j] -= min;
                }
            }

            //יצירת מסיכה המשמשת להבנת מצב שיבוץ החדרים והניתוחים
            var masks = new byte[h, w];
            //רשימה המייצגת את מצב שיבוץ החדרים 
            var rowsCovered = new bool[h];
            //רשימה המייצגת את מצב שיבוץ הניתוחים
            var colsCovered = new bool[w];

            //מעבר זה על המטריצה ממלא את המסיכה בערך 1 בתים שבהם הניתוח תואם לחדר בצורה מקסימלית (ערך הת הוא 0)
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (gradeMat[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                    {
                        masks[i, j] = 1;
                        rowsCovered[i] = true;
                        colsCovered[j] = true;
                    }
                }
            }

             //Location -   מבנה שמכיל מיקום  במטריצה - כלומר שיבוץ של חדר וניתוח
             //path - מערך של מיקומים
            var path = new Location[w * h];
            //משתנה שמכיל את השיבוץ התחלתי
            var pathStart = default(Location);  //הפונקציה default מאתחלת ערכי ברירת מחדל  
            //מספר צעד
            //בפעם הראשונה נבצע את צעד מספר 1
            var step = 1;

            //הסבר: אלגוריתם הונגרי משתמש בטבלת ציונים כדי להחליט על השיבוץ
            //לאחר יצירת הטבלה ועל בסיס הטבלה יצירת מסיכה שבה מסומנים השיבוצים האידיאליים
            //ישנם 4 צעדים שונים שניתן לעשות כדי להגיע לתוצאת השיבוץ
            //צעד 1 - הפעולה מבצעת בדיקה האם כל הניתוחים שובצו בחדרים אם כן מחזירה -1 אם לא מחזירה 2 - כלומר יש לעבור לצעד 2
            //צעד 2 - 
            //צעד 3 -
            //צעד 4 - 
            //כל עוד לא הגענו לתואצה של שיבוץ נמשיך בחד מן הצעדים לפי ההתאמה

            while (step != -1)
            {
                switch (step)
                {
                    case 1:
                        step = HungrienScudling.RunStep1(masks, colsCovered, w, h);
                        break;

                    case 2:
                        step = HungrienScudling.RunStep2(costs, masks, rowsCovered, colsCovered, w, h, ref pathStart);
                        break;

                    case 3:
                        step = HungrienScudling.RunStep3(masks, rowsCovered, colsCovered, w, h, path, pathStart);
                        break;

                    case 4:
                        step = HungrienScudling.RunStep4(costs, rowsCovered, colsCovered, w, h);
                        break;
                }
            }

            HungrienScudling.ClearCovers(rowsCovered, colsCovered, w, h);




            return gradeMat;
        }

        private static void ClearCovers(bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            for (var i = 0; i < h; i++)
            {
                rowsCovered[i] = false;
            }

            for (var j = 0; j < w; j++)
            {
                colsCovered[j] = false;
            }
        }
 
        //מחזירה -1 אם השיבוץ הסתיים ו-2 אם לא - מסמל שלא כל הניתוחים משובצים
        private static int RunStep1(byte[,] masks, bool[] colsCovered, int w, int h)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));
            //מסמן באיזה עמודות יש תאים שסומנו
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (masks[i, j] == 1)
                        colsCovered[j] = true;
                }
            }

            //סופר כמה עמודות סומנו סה''כ
            var colsCoveredCount = 0;

            for (var j = 0; j < w; j++)
            {
                if (colsCovered[j])
                    colsCoveredCount++;
            }

            // אם כל העמודות נבחרו - אם כל דבר שרצינו לשבץ מצא משבצת
            if (colsCoveredCount == h)
                return -1;

            return 2;
        }

        // הפונקציה????
        //מחזירה:
        //4 - אם אין תא מאופס במטריצת הציונים - אם אין עוד שום ניתוח שמתאים לשום חדר
        //3 - אם מצאנו שורה שבא רק אין עוד תא מאופס בשורה - אם מצאנו חדר שבו אין עוד ניתוח מתאים
        private static int RunStep2(int[,] gradeMat, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h, ref Location pathStart)
        {
            if (gradeMat == null)
                throw new ArgumentNullException(nameof(costs));

            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            while (true)
            {
                //מחפשת ניתוח ראשון שמשובץ באיזהו חדר
                var loc = HungrienScudling.FindZero(gradeMat, rowsCovered, colsCovered, w, h);
                if (loc.row == -1) //אם אין במטריצה שום ניתוח שמתאים לאיזשהוא חדר
                    return 4; //יש לעבור לצעד 4

                //משנה את התא במסיכה שהיה 1 להיות 2
                //שיבוץ החדר והניתוח נבחרו
                masks[loc.row, loc.column] = 2;

                var starCol = HungarianAlgorithm.FindStarInRow(masks, w, loc.row);
                //אם אכן יש עוד תא שערכו 1
                if (starCol != -1)  
                {
                    //מבחינת השורה הוא לא מעניין - כימצאנו תא  ?????????????????????????
                    //אץ החדר סידרנו וסימנו - כי מצאנו ניתוח שמשתבץ בו
                    rowsCovered[loc.row] = true;
                    //אבל בעמודות אני אסמן שהעמודה לא נבדקה - כי אולי זה התא היחיד בעמודה     ???????????????
                    //אבל לגבי הניתוח האחר שמצאנו שמתאים לחדר הזה - לא נסמן אותו - כי החדר הזה תפוס
                    colsCovered[starCol] = false;
                }
                //אם אכן אין עוד תא שערכו 1 - כלומר אין עוד אופציות בחדר הנוכחי

                else
                {
                    pathStart = loc; //חייב להיות שנתחיל מהמיקום הזה  - התא הראשון שנמצא
                    return 3;
                }
            }
        }
        private static int RunStep3(byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int w, int h, Location[] path, Location pathStart)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            var pathIndex = 0;
            path[0] = pathStart;

            while (true)
            {
                var row = HungarianAlgorithm.FindStarInColumn(masks, h, path[pathIndex].column);
                if (row == -1)
                    break;

                pathIndex++;
                path[pathIndex] = new Location(row, path[pathIndex - 1].column);

                var col = HungarianAlgorithm.FindPrimeInRow(masks, w, path[pathIndex].row);

                pathIndex++;
                path[pathIndex] = new Location(path[pathIndex - 1].row, col);
            }

            HungarianAlgorithm.ConvertPath(masks, path, pathIndex + 1);
            HungarianAlgorithm.ClearCovers(rowsCovered, colsCovered, w, h);
            HungarianAlgorithm.ClearPrimes(masks, w, h);

            return 1;
        }

        private static int RunStep4(int[,] gradeMat, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(gradeMat));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            var minValue = HungrienScudling.FindMinimum(gradeMat, rowsCovered, colsCovered, w, h);

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (rowsCovered[i])
                        gradeMat[i, j] += minValue;
                    if (!colsCovered[j])
                        gradeMat[i, j] -= minValue;
                }
            }
            return 2;
        }

        //מוצא את המינימום מבין כל התאים שנשארו שלא נבחרו לשיבוץ????????????????????????
        private static int FindMinimum(int[,] gradeMat, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            if (gradeMat == null)
                throw new ArgumentNullException(nameof(gradeMat));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            var minValue = int.MaxValue;

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (!rowsCovered[i] && !colsCovered[j])
                        minValue = Math.Min(minValue, gradeMat[i, j]);
                }
            }

            return minValue;
        }

        //מקבלת מסיכה ושורה שבה הפונקציה ??? מצאה תא שערכו 1 ושינתה אות ל-2
        //הפונקציה בודקת האם באותה שורה יש עוד תא שערכו 1
        // מחזירה:  את העמודה שבא נמצא תא נוסף או -1 במקרה שאין תא נוסף בשורה
        private static int FindStarInRow(byte[,] masks, int w, int row)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (var j = 0; j < w; j++)
            {
                if (masks[row, j] == 1)
                    return j;
            }

            return -1;
        }


        //מחפשת את המיקום של התא הראשון במטריצת הציונים שבו יש אפס - אם לא קיים תא מחזיר מיקום -1-1
        private static Location FindZero(int[,] gradeMat, bool[] rowsCovered, bool[] colsCovered, int w, int h)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (gradeMat[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                        return new Location(i, j);
                }
            }

            return new Location(-1, -1);
        }




        //מבנה שמכיל בצוכו משתנים לשורה ועמודה וכך מייצג מיקום במטריצה
        private struct Location
        {
            internal readonly int row;
            internal readonly int column;

            internal Location(int row, int col)
            {
                this.row = row;
                this.column = col;
            }
        }
    }
}
