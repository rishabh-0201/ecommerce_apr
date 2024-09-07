import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Service/product.service';
import { FormGroup, NgForm } from '@angular/forms';
import { NgFor } from '@angular/common';
<<<<<<< HEAD
import { Color, Processor, Product, RAM, ROM } from 'src/app/Model/Model';
=======
import { Color, Feature, Processor, Product, RAM, ROM } from 'src/app/Model/Model';
>>>>>>> 55f65d89ae4640258abf662e1d4e805f2c12e0b9

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  visible: boolean = false;
  selectedColor: any;
  selectedRam: any;
  selectedRom: any;
  selectedProcessor: any;
  product!: Product;
  selectedCategoryId = 0;
  products: any[] = [];
  Categories: any[] = [];
  Colors: Color[] = [];
  Rams: RAM[] = [];

  Rom: ROM[] = [];
  Processors: Processor[] = [];
  category: any = {

    categoryId: 0,
    categoryName: ''
  }
  featureDTO: any = {}
  ngOnInit(): void {
    this.CategoryList();
    this.ColorList();
    this.RamList();
    this.RomList();
    this.ProcessorList();

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
  ColorList() {

         this.productService.GetColor().subscribe({
          next:(res)=>{
            console.log(res);
          }
         })
  }
  RamList(){
    this.productService.GetRam().subscribe({
      next:(res)=>{
        console.log(res);
      }
     })
  }
  RomList(){
    this.productService.GetRom().subscribe({
      next:(res)=>{
        console.log(res);
      }
     })
  }
  ProcessorList(){
    this.productService.GetProcessor().subscribe({
      next:(res)=>{
        console.log(res);
      }
     })

  }
  addProduct(productForm: NgForm) {
    this.selectedCategory = this.selectedCategory.categoryId;

    console.log(this.selectedCategory)
    this.featureDTO.colorId = this.selectedColor.colorId;
    this.featureDTO.romId = this.selectedRom.romId;
    this.featureDTO.ramId = this.selectedRam.ramId;
    this.featureDTO.processorId = this.selectedProcessor.processorId
    console.log(this.featureDTO);
    this.product = {
      productName: productForm.value.productName,
      productDescription: productForm.value.productDescription,
      unitPrice: productForm.value.unitPrice,
      imageUrl: 'ghj',
      sellingPrice: 0,
      categoryId: this.selectedCategory,
      ramId: this.featureDTO.ramId,
      romId: this.featureDTO.romId,
      processorId: this.featureDTO.processorId,
      colorId: this.featureDTO.colorId
    }
    console.log(this.product);
    this.productService.addProduct(this.product).subscribe({
      next: (res) => {
        console.log(res);
      }
    });
    productForm.resetForm();
    this.visible = !this.visible;
  }


}
