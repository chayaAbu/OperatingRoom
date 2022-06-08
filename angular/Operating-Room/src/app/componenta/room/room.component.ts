import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Room } from 'src/app/model/Room';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  addRoomForm: any;
 
room:Room[]=[];
disableSelect = new FormControl();
  constructor(private db:DbService) { }

  ngOnInit(): void {
    this.addRoomForm = new FormGroup({
      date:new FormControl(''),
      class:this.disableSelect
      
     
    }
    )

  }
//  showClearRoom(){
//  console.log(this.selectedOption)
//   this.db.getClearRoom(Number.parseInt( this.selectedOption)).subscribe(res =>{
//     this.room=res;
//  })
// }

addRoom(){
  console.log(this.addRoomForm);
  const room: Room = {
    date: this.addRoomForm.controls.date.value,
    idClass: this.disableSelect.value,
    isFull:false,
    idRoom:15
   
    

  }
  console.log(room);
  this.db.addNewRoom(room).subscribe(res => {
    console.log(res)

    if (res == null)
      alert("שגיאת שרת")
    else
      alert("נוסף בהצלחה")
  })
}
}
