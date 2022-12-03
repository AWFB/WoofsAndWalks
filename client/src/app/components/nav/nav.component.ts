import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../services/account.service";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}

  // for use with angular's async pipe which auto unsubscribes - replaced by using account service
  // directly in the template
  // currentUser$: Observable<User | null> = of(null) // satisfy strict mode and assign value to observable

  constructor(public accountService: AccountService) { } // public so template can use it

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response) // remove me
      },
      error: error => console.log(error)
    })
  }

  logout() {
    this.accountService.logout(); // removes user from LS
  }

}
