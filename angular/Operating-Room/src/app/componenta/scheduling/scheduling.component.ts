import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-scheduling',
  templateUrl: './scheduling.component.html',
  styleUrls: ['./scheduling.component.css']
})
export class SchedulingComponent implements OnInit {

  constructor(private db:DbService) { }

  ngOnInit(): void {
  }

  sched(){
    
  }


}
