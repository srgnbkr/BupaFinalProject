import { PaymentType } from 'src/app/models/paymentType/paymentType';
import { PaymentService } from './../../services/paymentService/payment.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgModel, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PaymentTypeService } from 'src/app/services/paymentTypeService/payment-type.service';
import { Customer } from 'src/app/models/customer/customer';
import { CustomerService } from 'src/app/services/customerService/customer.service';
import { InsuredService } from 'src/app/services/insuredService/insured.service';
import { Insured } from 'src/app/models/insureds/insured';
import { NgSwitch } from '@angular/common';

@Component({
  selector: 'app-payment-add',
  templateUrl: './payment-add.component.html',
  styleUrls: ['./payment-add.component.scss'],
})
export class PaymentAddComponent implements OnInit {
  paymentAddForm!: FormGroup;
  paymentTypes: PaymentType[] = [];
  customers: Customer[] = [];
  insureds: Insured[] = [];
  customer! : Customer










  constructor(
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private paymentService: PaymentService,
    private paymentTypeService: PaymentTypeService,
    private customerService: CustomerService,
    private insuredService: InsuredService
  ) {}

  ngOnInit(): void {
    this.getAllPaymentType();
    this.getAllCustomer();
     //Optiondan gelen customerId'yi geçici olarak 12003 olarak atadım. null dönüyor?
  }

  createPaymentForm() {
    this.paymentAddForm = this.formBuilder.group({
      creditCardNumber: ['', Validators.required],
      cvv: ['', Validators.required],
      paymentPrice: ['', Validators.required],
      customerId: ['', Validators.required],
      insuredId: ['', Validators.required],
      paymentTypeId: ['', Validators.required],
    });
  }

  paymentAdd() {
    //this method is called when the user clicks the submit button
    if (this.paymentAddForm.valid) {
      let paymentModel = Object.assign({}, this.paymentAddForm.value);
      this.paymentService.addPayment(paymentModel).subscribe(
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

  getAllPaymentType() {
    this.paymentTypeService.getAllPaymentType().subscribe((response) => {
      this.paymentTypes = response.data;
    });
  }

  getAllCustomer() {
    this.customerService.customerGetAll().subscribe((response) => {
      this.customers = response.data;
    });
  }

  getInsuredCustomerId(customerId:number) {
    this.insuredService
      .getInsuredsByCustomerId(customerId)
      .subscribe((response) => {
        this.insureds = response.data;
        this.paymentAddForm.get('customerId')?.setValue(this.customer.id);
      });
  }

  handleKeyUp(event: any):void {
    console.log(event.target.value);

  }
}


