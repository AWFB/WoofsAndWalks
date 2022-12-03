import {Component, OnInit} from '@angular/core';
import {AccountService} from "./services/account.service";
import {User} from "./models/user";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Woofs and Walks';

  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
  this.setCurrentUser(); // set current user if in local storage
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user'); //could use ! to turn off type checking but a bit dodgy
    if (!userString) return; // If no user in local storage exit method
    const user: User = JSON.parse(userString); // else set user from LS
    this.accountService.setCurrentUser(user);
  }


}
