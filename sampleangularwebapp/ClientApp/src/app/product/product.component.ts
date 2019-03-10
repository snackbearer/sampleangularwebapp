import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from './product.service';
import { Product } from './product';
import { Location } from '@angular/common';

@Component({
  selector: 'product-data',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class productComponent {
  
  public product: Product;
  //public originalProduct: Product;
  public BaseURL: string;
  public productID: number;


  constructor(private productService: ProductService, private route: ActivatedRoute, private location: Location) {
    this.productID = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.createOrLoadProduct(this.productID);
  }

  private createOrLoadProduct(id: number) {
    if (id == -1) {
      // Create new product object
      this.initProduct();
    }
    else {
      // Get a product from product service
      this.productService.getProduct(id)
        .subscribe(product => {
          this.product = product;
          //this.originalProduct = Object.assign({}, this.product)
        });
    }
  }

  private initProduct(): void {
    // Add a new product
    this.product = new Product({
      
    });
    //this.originalProduct = Object.assign({}, this.product);
  }
  /*
  constructor(private router: Router, private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string,private http: HttpClient) {
    this.productID = this.route.snapshot.paramMap.get('id');
    this.BaseURL = baseUrl;

    http.get<ProductItem>(this.BaseURL + 'api/Product/' + this.productID).subscribe(result => {
      this.product = result;
    }, error => console.error(error));
    //this.product = { productId : 1, productCode : "tet", productName : "west" , productCost : 0};
    //this.product.productName = id;

  }
  */
  
  save(): void {

    if (this.product.productId) {
      // Update product
      this.productService.updateProduct(this.product)
        .subscribe(product => { this.product = product },
          () => null,
          () => this.dataSaved());
    }
    else {
      // Add a product
      this.productService.addProduct(this.product)
        .subscribe(product => { this.product = product },
          () => null,
          () => this.dataSaved());
    }

    //http: HttpClient;
    //this.http.post(this.BaseURL + 'api/Product', this.product).toPromise().then(this.navigateProductList).catch(this.errorOut);
    
    //this.router.navigate(['/productlist']); 
  }
  private dataSaved(): void {
    // Redirect back to list
    this.goBack();
  }

  goBack(): void {
    this.location.back();
  }

  cancel(): void {
    this.goBack();
  }
  navigateProductList(owner: productComponent): void {
    
    alert("Save complete!");
  }

  errorOut(error : Response): void {
    console.log(error);
    alert("save failed for the following reason" + error.text);
  }
  
  
}
