import { createSlice } from "@reduxjs/toolkit"

const initialState = {
    dishes: [],
    selectedDishById:null
}

const dishSlice = createSlice({
    name: "dishes",
    initialState,
    reducers: {
        addDish: (state, action) => {
            state.dishes.push(action.payload)
        },
        updateDish: (state, action) => {
            const index = state.dishes.findIndex((dish) => (
                dish.dishId === action.payload.dishId
            ))

            if (index !== -1) {
                state.dishes[index] = action.payload
            }

            //updating selectedDish if it matches with the updated dish Id
            if (state.selectedDishById?.dishId === action.payload.dishId)
                state.selectedDishById = action.payload
        },
        deleteDish: (state, action) => {
            state.dishes = state.dishes.filter((dish) => (
                dish.dishId !== action.payload
            ))
        },
        setDishById: (state, action) => {
            state.selectedDishById = action.payload
        },
        setDishes: (state, action) => {
            state.dishes = action.payload
        }
    }
})

export const  {setDishes,setDishById,deleteDish,updateDish,addDish} = dishSlice.actions

export default dishSlice.reducer