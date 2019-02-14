import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'productlist-data',
  templateUrl: './productlist.component.html'
})
export class productlistComponent {
   _filter: string;
  public productList: ProductItem[];
  public filteredproductList: ProductItem[];

  get listfilter(): string {
    return this._filter;
  }
  set listfilter(value: string) {
    this._filter = value;
    this.filteredproductList = this.listfilter ? this.performFilter(this.listfilter) : this.productList;

  }

  performFilter(filtertext: string): ProductItem[] {
    return this.productList.filter((product: ProductItem) => product.productName.indexOf(filtertext) != -1);
  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ProductItem[]>(baseUrl + 'api/ProductList/ProductList').subscribe(result => {
      this.productList = result;
      this.filteredproductList = this.productList;
      //this.listfilter = 'cart';
    }, error => console.error(error));

    
  }
}

interface ProductItem {
  productID: number;
  productCode: string;
  productName: string;
}
