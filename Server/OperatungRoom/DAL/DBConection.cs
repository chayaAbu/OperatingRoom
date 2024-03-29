﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace DAL
{
    public class DBConection
    {
        public DBConection() { }
        public List<T> GetDbSet<T>() where T : class
        {
            using (OpreatingRoomEntities1 db = new OpreatingRoomEntities1())
            {
                return db.GetDbSet<T>().ToList();
            }
        }
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
        {
            using (OpreatingRoomEntities1 db = new OpreatingRoomEntities1())
            {
                var model = db.Set<T>();
                switch (exAction)
                {
                    case ExecuteActions.Insert:
                        model.Add(entity);
                        break;
                    case ExecuteActions.Update:
                        model.Attach(entity);
                        db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        break;
                    case ExecuteActions.Delete:
                        model.Attach(entity);
                        db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
                
            }

        }
        }

    }

