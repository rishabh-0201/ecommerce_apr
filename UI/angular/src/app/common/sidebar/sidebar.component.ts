import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  heading ='E-Commerce_APR'
  menuItemlist = [
    {
      id: 1,
      title: 'Dashboard',
      path: '/dashboard',
      icon: 'pi pi-home',
      class: 'dashboard',
      submenu: [],
      showSubMenu: false
    },
    {
      id: 2,
      title: 'Vendor-List',
      path: 'vendor',
      submenu: [],
      showSubMenu: false
    }
    // {
    //   id: 2,
    //   title: 'Settings',
    //   path: '',
    //   icon: 'pi pi-cog',
    //   class: 'settings',
    //   submenu: [
    //     { path: '/settings/profile', title: 'Profile', icon: 'pi pi-user' },
    //     { path: '/settings/account', title: 'Account', icon: 'pi pi-lock' }
    //   ],
    //   showSubMenu: false
    // },
    // Add more menu items as needed
  ];

  toggleSubMenu(menu: any) {
    menu.showSubMenu = !menu.showSubMenu;
  }
}
