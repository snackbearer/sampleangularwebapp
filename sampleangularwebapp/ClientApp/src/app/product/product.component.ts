import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from './product.service';
import { Product } from './product';
import { FormGroup } from '@angular/forms';

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
  public productForm: FormGroup;
  

  constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router) {
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
          
        });
    }
  }

  private initProduct(): void {
    // Add a new product
    this.product = new Product({
      
    });
    
  }
  

  onSubmit() {
    this.save();
  }

  save(): void {

    if (this.product.productId) {
      // Update product
      this.productService.updateProduct(this.productID, this.product)
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
    
  }
  private dataSaved(): void {
    // Redirect back to list
    this.goBack();
  }

  goBack(): void {

    this.router.navigate(["/productlist"]);
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
