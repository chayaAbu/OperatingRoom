import { Component, OnInit } from '@angular/core';
import { CalendarEvent, CalendarView } from 'angular-calendar';
import { startOfDay } from 'date-fns';
import { Scheduling } from 'src/app/model/Scheduling';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.css']
})
export class SchedulingComponent implements OnInit {
  schedu: Scheduling[] = [];
  viewDate: Date = new Date();
  view: CalendarView = CalendarView.Week;
  CalendarView = CalendarView;

  setView(view: CalendarView) {
    this.view = view;
  }

  events: CalendarEvent[] = [
    // {
    //   start: startOfDay(new Date()),
    //   title: 'First event',
    // },
    // {
    //   start: startOfDay(new Date()),
    //   title: 'Second event',
    // }
  ]
  constructor(private db: DbService) { }

  ngOnInit(): void {
    // this.schedu.forEach(s => {
    //   this.events.push(
    //     {
    //       start: startOfDay(s.schedulingDate),
    //       title: 'surgery:' + s.surgeryCode + '\nroom:' + s.idRoom
    //     }
    //   )
    // });
    // console.log("events:" + this.events);
    
  }

  // ngOnChange(): void {

  // }


  sched() {
    this.db.doSched().subscribe(res => {
      this.schedu = res;
      // this.schedu.forEach(s => {
      //   this.events.push(
      //     {
      //       start: startOfDay(new Date(s.schedulingDate)),
      //       title: 'surgery:' + s.surgeryCode + '\nroom:' + s.idRoom
      //     }
      //   )
      // });
      // window.location.reload()
      // console.log("events:" + this.events);

    },
      // err => {
      //   console.log("error:" + err.message);
      // }
    )
  }


  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    console.log(date);
    //this.openAppointmentList(date)
  }
}
