import { PolicyService } from './../../services/policyService/policy.service';
import { CartItem } from './../../models/cart-item/cartItem';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { InsuredService } from './../../services/insuredService/insured.service';
import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer/customer';
import { CustomerService } from 'src/app/services/customerService/customer.service';
import { CartItemService } from 'src/app/services/cartItemService/cart-item.service';
import { Policy } from 'src/app/models/policy/policy';

@Component({
  selector: 'app-insured-add',
  templateUrl: './insured-add.component.html',
  styleUrls: ['./insured-add.component.scss'],
})
export class InsuredAddComponent implements OnInit {
  insuredAddForm!: FormGroup;
  customers: Customer[] = [];
  cartItems:CartItem[]=[];
  policies:Policy[]=[];



  constructor(
    private insuredService: InsuredService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private cartItemService:CartItemService,
    private policyService: PolicyService
  ) {}

  ngOnInit(): void {
    this.getAllCustomer();
    this.createInsuredAddForm();
    this.getCurrentPolicy();
    this.getPolicies();
  }

  createInsuredAddForm() {
    this.insuredAddForm = this.formBuilder.group({
      insuredFirstName: ['', Validators.required],
      insuredLastName: ['', Validators.required],
      identityNumber: ['', Validators.required],
      birthYear: ['', Validators.required],
      gender: ['', Validators.required],
      degree: ['', Validators.required],
      weight: ['', Validators.required],
      height: ['', Validators.required],
      customerId: ['', Validators.required],
      policyId: ['', Validators.required],
    });
  }

  insuredAdd() {
    if (this.insuredAddForm.valid) {
      let insuredModel = Object.assign({}, this.insuredAddForm.value);
      this.insuredService.addInsured(insuredModel).subscribe(
        (response) => {
          this.toastrService.success(response.message, 'Başarılı');
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            console.log(responseError.error.ValidationErrors); //apiden gelen doğrulama hatalarının döndürdüğü alan
            for (
              let i = 0;
              i < responseError.error.ValidationErrors[i].ErrorMessage.length;
              i++
            ) {
              this.toastrService.error(
                responseError.error.ValidationErrors[i].ErrorMessage,
                'Doğrulama hatası'
              );
            }
          }
        }
      );
    } else {
      this.toastrService.error('Tüm alanları doldurun.', 'Dikkat');
    }
  }

  getAllCustomer() {
    this.customerService.customerGetAll().subscribe((response) => {
      this.customers = response.data;
    });
  }

  getCurrentPolicy(){
    this.cartItemService.list();


  }


  getPolicies(){
    this.policyService.getPolicies().subscribe(response=>{
      this.policies = response.data;

    })
  }


}
