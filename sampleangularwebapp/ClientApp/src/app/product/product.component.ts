import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'product-data',
  templateUrl: './product.component.html'
})
export class productComponent {
  
  public product: ProductItem;
  public BaseURL: string;
  public productID: string;

  constructor(private router: Router, private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string,private http: HttpClient) {
    this.productID = this.route.snapshot.paramMap.get('id');
    this.BaseURL = baseUrl;

    http.get<ProductItem>(this.BaseURL + 'api/Product/' + this.productID).subscribe(result => {
      this.product = result;
    }, error => console.error(error));
    //this.product = { productId : 1, productCode : "tet", productName : "west" , productCost : 0};
    //this.product.productName = id;

  }
  
  back(): void {
    this.router.navigate(['/productlist']);  
  }

  save(): void {

    //http: HttpClient;
    this.http.post(this.BaseURL + 'api/Product', this.product).toPromise().then(this.navigateProductList).catch(this.errorOut);
    
    //this.router.navigate(['/productlist']); 
  }

  navigateProductList(owner: productComponent): void {
    
    alert("Save complete!");
  }

  errorOut(error : Response): void {
    console.log(error);
    alert("save failed for the following reason" + error.text);
  }
  ngOnInit() { }
  
}
