import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  //@Input() name: string;
  constructor() { }

  ngOnInit(): void {
  }

  toggleSubLinks(subLinks: any) {
    document.getElementById(subLinks)?.classList.toggle('open');
  }

  toggleSidebar(sidebar: any) {
    let sidebarEL = document.getElementById(sidebar);
    sidebarEL?.classList.toggle('open');
    if (sidebarEL?.classList.contains('open')) {
      document.body.classList.add('mode-on')
      document.body.classList.remove('mode-off')
    } else {
      document.body.classList.remove('mode-on')
      document.body.classList.add('mode-off')
    }
  }

}
