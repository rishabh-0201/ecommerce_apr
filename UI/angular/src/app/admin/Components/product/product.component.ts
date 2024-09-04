import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Service/product.service';
import { FormGroup, NgForm } from '@angular/forms';
import { NgFor } from '@angular/common';
import { Product } from 'src/app/Model/Model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  visible: boolean = false;
  products: any[] = [];
  Categories: any[] = [];
  category: any = {
    categoryId: 0,
    categoryName: ''
  }
  categoryId: number = 0;
  product: any = {};
  ngOnInit(): void {
    this.CategoryList();
  }
  constructor(private productService: ProductService) { }

  confirm() {
    this.visible = !this.visible;
  }
  CategoryList() {
    this.productService.GetCategories().subscribe({
      next: (res) => {
        this.Categories = res;
        console.log(res);
      }
    });
  }
  addProduct(productForm: NgForm) {
    this.categoryId = this.category.categoryId;
    this.product = {
      productName: productForm.value.productName,
      productDescription: productForm.value.productDescription,
      unitPrice: productForm.value.unitPrice,
      categoryId: this.categoryId,
    }
    this.productService.addProduct(productForm).subscribe({
      next: (res) => {
        console.log(res);
      }
    });
    // console.log(productForm);
    productForm.resetForm();
    this.visible = !this.visible;
  }

  
}
