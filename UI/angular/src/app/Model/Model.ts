export interface City{
    id?:number,
    name:string,
    stateId:number
    
}
export interface State{
    stateId:number,
    stateName:string
    
}
export interface Vendor{
    vendorName: string,
    contactPerson: string,
    phoneNumber: string,
    email: string,
    address: string,
    cityId:number,
    stateId: number,
    companyId: number
}

export interface Product{

    productName: string,
    productDescription: string,
    categoryId: number,
    attributeId: number,
    imageUrl: string
    sellingPrice: Float32Array,
    UnitPrice: Float32Array 
}

export interface Category{

    categoryId: number,
    categoryName: string
}