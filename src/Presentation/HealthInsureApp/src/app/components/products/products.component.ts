import { ListResponseModel } from 'src/app/models/base/listResponseModel';
import { Policy } from './../../models/policy/policy';
import { PolicyService } from 'src/app/services/policyService/policy.service';
import { Component, OnInit } from '@angular/core';
import { CartItemService } from 'src/app/services/cartItemService/cart-item.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  policies: Policy[] = [];

  constructor(private policyService: PolicyService,private cartService:CartItemService) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.policyService.getPolicies().subscribe((response) => {
      this.policies = response.data;
    });
  }

  addToCart(policy: Policy) {
    this.cartService.addToCart(policy);
  }



}
