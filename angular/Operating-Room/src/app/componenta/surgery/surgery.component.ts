import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  constructor(private db: DbService) { }

  ngOnInit(): void {
    this.addSurgeryForm = new FormGroup({
      tz:new FormControl(''),
    }
    )
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

}
