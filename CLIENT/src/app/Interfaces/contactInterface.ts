export interface ContactInterface{
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    dateOfBirth: string,
    categoryId: number,
    categoryName: string,
    subCategoryId?: number,
    subCategoryName?: string,
}