import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Surgery } from 'src/app/model/Surgery';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-emergency',
  templateUrl: './emergency.component.html',
  styleUrls: ['./emergency.component.css']
})
export class EmergencyComponent implements OnInit {
emergency:Surgery[]=[];
addSurgeryForm: any;
disableSelect = new FormControl(false);
  constructor(private db: DbService ,private route:Router) { }

  ngOnInit(): void {
    this.addSurgeryForm = new FormGroup({
      date: new FormControl(''),
      danger: new FormControl(''),
      sTime:new FormControl(''),
      class: this.disableSelect
    }
    )
  }


  addEmergency() {
    console.log(this.addSurgeryForm);
    const surgery: Surgery = {
      surgeryDate: this.addSurgeryForm.controls.date.value,
      idClass: this.disableSelect.value,
      priorityLevel:0,
      dangerLevel: this.addSurgeryForm.controls.danger.value,
      idDoctor: 213256685,
      surgeryCode: 18,
      duringSurg:this.addSurgeryForm.controls.sTime.value,
      hasSches:false
    }
    console.log(surgery);
    this.db.emergency(surgery).subscribe(res => {
      console.log(res)
      this.db.surgeryKod=res.surgeryCode;

      if (res == null)
        alert("שגיאת שרת")
      else
        alert(res.surgeryCode+" נוסף בהצלחה")
        this.route.navigate(['scheduling'])
    })

  }
}
