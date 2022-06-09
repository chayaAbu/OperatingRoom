import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Device } from 'src/app/model/Device';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit {
  selectedOption!: string;
  addDeviceForm: any;
  device: Device[] = [];
  constructor(private db: DbService) {

  }

  ngOnInit(): void {
    this.addDeviceForm = new FormGroup({
      name: new FormControl(''),
      amount: new FormControl('')
    })

  }

  addDevice() {
    console.log(this.addDeviceForm);
    const  device: Device = {
      idDevice:0,
      isAvailable:false,
      deviceName:this.addDeviceForm.controls.name.value,
      date:'2022-05-26',
      amount:this.addDeviceForm.controls.amount.value,



    }
    console.log(device);
    this.db.addNewDevice(device).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
    })
  }

}
