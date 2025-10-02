import React from 'react'
import {Container,AddDish as AddDishComponent} from "../components/index"

function AddDish() {
    return (
        <div className='py-8'>
            <Container>
                <AddDishComponent />
            </Container>
        </div>
    )
}

export default AddDish