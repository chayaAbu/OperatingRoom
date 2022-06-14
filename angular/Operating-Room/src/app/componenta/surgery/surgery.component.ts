import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Surgery } from 'src/app/model/Surgery';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-surgery',
  templateUrl: './surgery.component.html',
  styleUrls: ['./surgery.component.css']
})
export class SurgeryComponent implements OnInit {
  surgery: Surgery[] = [];
  addSurgeryForm: any;
  disableSelect = new FormControl(false);
  constructor(private db: DbService ,private route:Router) { }

  ngOnInit(): void {
    this.addSurgeryForm = new FormGroup({
      date: new FormControl(''),
      priority: new FormControl(''),
      danger: new FormControl(''),
      class: this.disableSelect
    }
    )
  }

  addSurgery() {
    console.log(this.addSurgeryForm);
    const surgery: Surgery = {
      surgeryDate: this.addSurgeryForm.controls.date.value,
      idClass: this.disableSelect.value,
      priorityLevel: this.addSurgeryForm.controls.priority.value,
      dangerLevel: this.addSurgeryForm.controls.danger.value,
      idDoctor: 213256685,
      surgeryCode: 18

    }
    console.log(surgery);
    this.db.addNewSergery(surgery).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
        this.moveToRequest(res.surgeryCode);
    })

  }
  setDanger(v: string) {
    console.log('j');
    
    console.log(v);

  }
  shoeSurgeryFromCurrentDate() {
    this.db.getSurgeryFromCurrentDate().subscribe(res => {
      this.surgery = res;
    })
  }

  shoeSurgeryFromSpecifictDate(today: Date) {
    this.db.getSurgeryFromSpecificDate(today).subscribe(res => {
      this.surgery = res;
    })
  }
  moveToRequest(sCode:Number){
   this.route.navigate(['device'],{state:{sCode}})
  }
}
