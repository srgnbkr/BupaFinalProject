import { CartItem } from './../../models/cart-item/cartItem';
import { CartItemService } from './../../services/cartItemService/cart-item.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-current-policy',
  templateUrl: './current-policy.component.html',
  styleUrls: ['./current-policy.component.scss']
})
export class CurrentPolicyComponent implements OnInit {

  cartItems:CartItem[] = [];

  constructor(private cartSerivce : CartItemService) { }

  ngOnInit(): void {
    this.getList();
  }


  getList(){
    this.cartItems = this.cartSerivce.list()
  }

}
