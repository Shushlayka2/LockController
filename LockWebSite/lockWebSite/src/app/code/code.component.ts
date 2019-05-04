import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Code } from './code';
import { CodeService } from './code.service';
import { AuthenticationService } from '../user/authentication.service';

@Component({
  templateUrl: 'code.component.html',
  styleUrls: ['./code.component.css']
})
export class CodeComponent implements OnInit {

  loading = false;
  codes: Code[];

  constructor(
    private router: Router,
    private codeService: CodeService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.getExistingCodes();
  }

  getExistingCodes() {
    this.loading = true;
    this.codeService.getCodes().subscribe(codes => {
      this.codes = codes;
      this.loading = false;
    });
  }

  generateNewCode() {
    this.loading = true;
    this.codeService.generateNewCode().subscribe(codes => {
      this.codes = codes;
      this.loading = false;
    });
  }

  deleteCode(code: Code) {
    this.loading = true;
    this.codeService.delteCode(code).subscribe(codes => {
      this.codes = codes;
      this.loading = false;
    });
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
