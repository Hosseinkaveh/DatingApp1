import { Component, OnInit } from '@angular/core';
import { AccountService } from '../Services/account.service';
import { MembersService } from '../Services/members.service';
import { member } from '../_models/member';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  members: member[];

  constructor(public accountService: AccountService, private memberSerice: MembersService) { }

  ngOnInit(): void {
    this.loadMembers();

  }

  loadMembers() {
    this.memberSerice.getMembers().subscribe({
      next: respons => this.members = respons,
      complete: () => console.log(this.members)
    }
    )
  }

}
