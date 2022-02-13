import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/cart-item/cartItem';
import { CartItemService } from 'src/app/services/cartItemService/cart-item.service';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: ['./cart-summary.component.scss']
})
export class CartSummaryComponent implements OnInit {

  cartItems: CartItem[]=[];

  constructor(private cartService :CartItemService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart(){
    this.cartItems = this.cartService.list();
  }



}
