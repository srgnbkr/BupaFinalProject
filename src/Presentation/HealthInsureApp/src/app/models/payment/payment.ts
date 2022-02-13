export interface Payment {
  id: number;
  creditCardNumber: string;
  cvv: string;
  paymentPrice: number;
  customerId: number;
  insuredId: number;
  paymentTypeId: number;
}
