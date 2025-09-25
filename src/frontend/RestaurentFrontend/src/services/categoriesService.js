import axiosInstance from "../axios/axiosInstance"


export class CategoryService{
    async GetCategories(){
        try {
            let response = await axiosInstance.get("/Categories")
            return response.data

        } catch (error) {
            console.log("CategorService :: GetCategories :: ",error)
            return false
        }
    }

    async GetategoryById(categoryId){
        try {
            let response = await axiosInstance.get(`/Categories/${categoryId}`)
            return response.data
        
        } catch (error) {
            console.log("CategorService :: GetCategoryById :: ",error)
            return false
        }
    }
}

const categoryService = new CategoryService()
export default categoryService