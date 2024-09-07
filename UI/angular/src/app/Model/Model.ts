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

    productName: string;
    productDescription: string;
    categoryId: number;
    ramId:number;
    romId:number;
    processorId:number;
    colorId:number;
    unitPrice: Float32Array 
    sellingPrice:number
    imageUrl:string
}
export interface Feature{
    RamId:number,
    RomId:number,
    ColorId:number,
    processorId:number
}

export interface Category{

    categoryId: number,
    categoryName: string
}
export interface Color{
    colorId:number,
    colorName:string
}
export interface RAM{
    ramId:number,
    ramValue:string
}
export interface ROM{
    romId:number,
    romValue:string
}
export interface Processor{
    processorId:number,
    processorValue:string
}
// export interface Attribute{
//     productId:number,
//     ramId:number,
// }

