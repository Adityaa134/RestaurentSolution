import axiosInstance from "../axios/axiosInstance";

export class CartService{
    async AddItemToCart(userId,dishId){
        try {
            const response = await axiosInstance.post(`/Dishes/add-to-cart`,{
                UserId:userId,
                DishId:dishId
            })
            return response.data
        } catch (error) {
            console.log("CartService :: AddItemToCart :: ",error)
        }
    }

    async GetCartItems(userId){
        try {
            if(userId==undefined){
               let response = await axiosInstance.get(`/Dishes/GetCartItems`);
               return response.data
            }
            let response = await axiosInstance.get(`/Dishes/GetCartItems?userId=${userId}`);
            return response.data
        } catch (error) {
            console.log("CartService :: GetCartItems :: ",error)
        }
    }

    async UpdateQuantity(quantity,cartId){
        try {
            let response = await axiosInstance.put(`/Dishes/update-quantity`,{
                Quantity:quantity,
                CartId:cartId
            })
            return response.data
        } catch (error) {
            console.log("CartService :: UpdateQuantity :: ",error)
        }
    }

    async CheckCartItemExist(userId,dishId){
        try {
            if(userId==undefined){
                let response = await axiosInstance.get(`/Dishes/CheckCartItemExist?&dishId=${dishId}`)
                return response.data
            }
            let response = await axiosInstance.get(`/Dishes/CheckCartItemExist?userId=${userId}&dishId=${dishId}`)
            return response.data
        } catch (error) {
            console.log(error)
            return false;
        }
    }
}

const cartService = new CartService()
export default cartService