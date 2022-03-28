import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/model/Room';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  
room:Room[]=[];
  constructor(private db:DbService) { }

  ngOnInit(): void {
  }

}
