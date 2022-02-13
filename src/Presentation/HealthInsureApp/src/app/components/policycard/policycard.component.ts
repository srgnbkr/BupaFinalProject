import { Policy } from './../../models/policy/policy';
import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/services/policyService/policy.service';

@Component({
  selector: 'app-policycard',
  templateUrl: './policycard.component.html',
  styleUrls: ['./policycard.component.scss']
})
export class PolicycardComponent implements OnInit {

  policies: Policy[]=[];

  constructor(private policyService:PolicyService) { }

  ngOnInit(): void {
    this.getAllPolicies();
  }

  getAllPolicies(){
    this.policyService.getPolicies().subscribe(
      (res) => {
        this.policies = res.data;
      }
    )
  }

}
