import { InsuredAddComponent } from './components/insured-add/insured-add.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { PaymentAddComponent } from './components/payment-add/payment-add.component';

const routes: Routes = [
  {path:'products',component:ProductsComponent},
  {path:'',pathMatch:"full",component:HomeComponent},
  {path:'insuredAdd',component:InsuredAddComponent},
  {path:'paymentAdd',component:PaymentAddComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
