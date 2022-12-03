import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

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

  constructor(public accountService: AccountService,
              private router: Router,
              private toastr: ToastrService) { } // public so template can use it

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: _ => this.router.navigateByUrl('/members'),
      error: error => this.toastr.error(error.error)
    })
  }

  logout() {
    this.accountService.logout(); // removes user from LS
    this.router.navigateByUrl('/')
  }

}
