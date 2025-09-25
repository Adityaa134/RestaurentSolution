import React, { useId } from 'react'

function Select({
    options,
    label,
    className,
    ...props
}, ref) {
    const id = useId()
    return (
        <div className='w-full'>
            {label && <label htmlFor={id} className='block text-gray-700 text-sm mb-1'>{label}</label>}
            <select
                {...props}
                id={id}
                ref={ref}
                className={`px-3 py-2 rounded-lg bg-white text-black outline-none focus:bg-gray-50 duration-200 border border-gray-200 w-full ${className}`}
            >
                <option value="" >
                    Select a category
                </option>

                {options?.map((option) => (
                    <option key={option.categoryId} value={option.categoryId}>
                        {option.cat_Name}
                    </option>
                ))}
            </select>
        </div>
    )
}

export default React.forwardRef(Select)