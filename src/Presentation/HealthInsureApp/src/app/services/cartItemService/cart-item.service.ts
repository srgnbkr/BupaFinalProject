import { CartItems } from './../../models/cart-item/cartItems';
import { CartItem } from './../../models/cart-item/cartItem';

import { Injectable } from '@angular/core';
import { Policy } from 'src/app/models/policy/policy';

@Injectable({
  providedIn: 'root',
})
export class CartItemService {
  constructor() {}

  addToCart(policy: Policy) {
    let cartItem = new CartItem();
    cartItem.policy = policy;
    CartItems.push(cartItem);
  }

  list(): CartItem[] {
    return CartItems;
  }
}
