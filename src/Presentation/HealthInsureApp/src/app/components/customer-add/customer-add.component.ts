import { CustomerService } from './../../services/customerService/customer.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.scss'],
})
export class CustomerAddComponent implements OnInit {
  customerAddForm!: FormGroup;
  customerFirstName!:string

  constructor(
    private customerService: CustomerService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.createCustomerAddForm();
  }

  createCustomerAddForm() {
    this.customerAddForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      identityNumber: ['', Validators.required],
      birthYear: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
    });
  }

  customerAdd() { //this method is called when the user clicks the submit button
    if (this.customerAddForm.valid) {
      let customerModel = Object.assign({}, this.customerAddForm.value);
      this.customerService.customerAdd(customerModel).subscribe(
        (response) => {
          this.toastrService.success(response.message, 'Başarılı');
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            console.log(responseError.error.ValidationErrors); //apiden gelen doğrulama hatalarının döndürdüğü alan
            for (let i = 0; i < responseError.error.ValidationErrors[i].ErrorMessage.length; i++) {
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
}
