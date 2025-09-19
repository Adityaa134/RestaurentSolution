import React, { useId } from 'react'

const Input = React.forwardRef(function Input({
  type = 'text',
  className = '',
  label,
  ...props
}, ref) {      

  const id = useId()
  return (
    <div className='w-full'>
      {label && <label className='block text-gray-700 text-sm mb-1'
        htmlFor={id}
      >
        {label}
      </label>}

      <input
        type={type}
        className={` w-full px-3 py-2  ${className}`}
        ref={ref}
        id={id}
        {...props}
      />

    </div>
  )

})

export default Input