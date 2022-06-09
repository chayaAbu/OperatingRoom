import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Device } from 'src/app/model/Device';
import { Surgery } from 'src/app/model/Surgery';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit {
  disableSelect = new FormControl(false);
  addDeviceForm: any;
  addRwquestDeviceForm: any;
  device: Device[] = [];
  surgery:Surgery[] = [];

  constructor(private db: DbService) {

  }

  ngOnInit(): void {
    this.addDeviceForm = new FormGroup({
      name: new FormControl(''),
      amount: new FormControl(''),
      sCode: new FormControl('')
    })

  }

  addDevice() {
    console.log(this.addDeviceForm);
    const device: Device = {
      idDevice: 0,
      isAvailable: false,
      deviceName: this.addDeviceForm.controls.name.value,
      date: '2022-05-26',
      amount: this.addDeviceForm.controls.amount.value,
      surgeryCode: 0


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

  addrequest() {
    console.log(this.addRwquestDeviceForm);
    const device: Device = {
      idDevice: 0,
      isAvailable: false,
      deviceName: this.disableSelect.value,
      date: '2022-05-26',
      amount: this.addRwquestDeviceForm.controls.amount.value,
      surgeryCode: this.addRwquestDeviceForm.controls.sCode.value


    }
    console.log(device);
    this.db.addNewRequestDevice(device).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
    })
  }




  // shoeSurgeryFromCurrentDate() {
  //   this.db.getSurgeryFromCurrentDate().subscribe(res => {
  //     this.surgery = res;
  //   })
  // }

}
