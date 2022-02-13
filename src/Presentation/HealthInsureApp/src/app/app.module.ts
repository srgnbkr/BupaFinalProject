import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import {BrowserAnimationsModule} from "@angular/platform-browser/animations"

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PolicycardComponent } from './components/policycard/policycard.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { CustomerAddComponent } from './components/customer-add/customer-add.component';

import {ToastrModule} from "ngx-toastr";
import { ProductsComponent } from './components/products/products.component';
import { InsuredAddComponent } from './components/insured-add/insured-add.component';
import { PaymentAddComponent } from './components/payment-add/payment-add.component';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { CurrentPolicyComponent } from './components/current-policy/current-policy.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PolicycardComponent,
    HomeComponent,
    FooterComponent,
    CustomerAddComponent,
    ProductsComponent,
    InsuredAddComponent,
    PaymentAddComponent,
    CartSummaryComponent,
    CurrentPolicyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass:"toast-bottom-right"
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
