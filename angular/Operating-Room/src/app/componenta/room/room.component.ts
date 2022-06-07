import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/model/Room';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  addRoomForm: any;
  selectedOption!: string;
room:Room[]=[];
  constructor(private db:DbService) { }

  ngOnInit(): void {
  }
 showClearRoom(){
 console.log(this.selectedOption)
  this.db.getClearRoom(Number.parseInt( this.selectedOption)).subscribe(res =>{
    this.room=res;
 })
}
}
