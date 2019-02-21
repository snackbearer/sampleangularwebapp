import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterModule, Routes, Router } from '@angular/router';
import { ProductService } from './product.service';
import { Product } from './product';

@Component({
  selector: 'productlist-data',
  templateUrl: './productlist.component.html'
})
export class productlistComponent {
   _filter: string;
  public productList: Product[];
  public filteredproductList: Product[];

  constructor(private router: Router, private productservice : ProductService) {
    
  }

  ngOnInit() {

    this.reloadProducts();
    
  }

  reloadProducts(): void {

    this._filter = "";

    this.productservice.getProducts().subscribe(product => {
      this.productList = product;
      this.filteredproductList = product;
    });

  }


  get listfilter(): string {
    return this._filter;
  }
  set listfilter(value: string) {
    this._filter = value;
    this.filteredproductList = this.listfilter ? this.performFilter(this.listfilter) : this.productList;

  }

  performFilter(filtertext: string): Product[] {
    return this.productList.filter((product: Product) => product.productName.indexOf(filtertext) != -1);
  }

  add(): void {
    this.router.navigate(["/product", "-1"]); 
  }

  deleteProduct(productID: number): void {
    this.productservice.deleteProduct(productID).subscribe(
      () => null,
      () => null,
      () => this.reloadProducts());
  }

  /*
  constructor(private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ProductItem[]>(baseUrl + 'api/Product').subscribe(result => {
      this.productList = result;
      this.filteredproductList = this.productList;
      //this.listfilter = 'cart';
    }, error => console.error(error));
    
  }
  */
}
