import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  chooseImage(event: any) {
    var image = document.getElementById('output');
    image.setAttribute('src', URL.createObjectURL(event.target.files[0]) );
}

}
