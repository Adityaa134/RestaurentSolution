import React from 'react'
import { Link } from 'react-router-dom'
import { Button } from "../index"

function DishCard({ dishId, dishName, price,
    dish_Image_Path
}) 
{
   
    const imageUrl = `https://localhost:7219${dish_Image_Path}`
    
    return (
        <Link to={`/dish/${dishId}`}>
            <div className="max-w-xs bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition-shadow duration-300">

                <img
                    className="w-full h-40 object-cover"
                    src={imageUrl}
                    alt="Dish Image"
                />


                <div className="p-4">

                    <h2 className="text-lg font-semibold text-gray-800">{dishName}</h2>


                    <p className="text-blue-600 font-bold text-base mt-1">₹{price}</p>

                    <Button type='submit' className='mt-3 w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600 transition-colors' >
                        Order Now
                    </Button>

                </div>
            </div>

        </Link>
    )
}

export default DishCard