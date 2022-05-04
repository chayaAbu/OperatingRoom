import { Component, OnInit } from '@angular/core';
import { Device } from 'src/app/model/Device';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit {
  selectedOption!: string;
 device:Device | undefined;
  constructor(private db: DbService) {
    
   }

  ngOnInit(): void {
  }

}
