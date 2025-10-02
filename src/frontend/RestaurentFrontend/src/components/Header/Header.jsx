import React, { useEffect, useState } from 'react'
import { useNavigate } from "react-router-dom"
import { useSelector } from "react-redux"
import { Container, LogOutBtn } from "../index"
import { NavLink } from 'react-router-dom'
import { ShoppingCartIcon } from "@heroicons/react/24/outline";
import { SearchBar } from "../index"

function Header() {

  const navigate = useNavigate()
  const authStatus = useSelector((state) => state.auth.authStatus)
  const { userData } = useSelector((state) => state.auth)
  const userType = useSelector((state) => state.auth.role)
  const [cartCount, setCartCount] = useState(0)
  const cartItems = useSelector((state) => state.carts.cartItems)

  useEffect(() => {
    setCartCount(cartItems?.length || 0);
  }, [cartItems])

  const navItems = [
    {
      url: "/",
      name: "Home",
      active: true
    },
    {
      url: "/login",
      name: "Login",
      active: !authStatus
    },
    {
      url: "/register",
      name: "Register",
      active: !authStatus
    },
    {
      url: "/categories",
      name: "Categories",
      active: true
    },
    {
      url: "/add-dish",
      name: "AddDish",
      active: (userType === "admin" && authStatus) ? true : false
    }
  ]

  const leftNavItems = navItems.filter(
    (item) => item.name !== "Login" && item.name !== "Register"
  );
  const rightNavItems = navItems.filter(
    (item) => item.name === "Login" || item.name === "Register"
  );


  return (

    <header className="bg-white shadow-sm border-b border-gray-200">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <nav className="flex items-center justify-between h-16">
          <ul className="flex space-x-8">
            {leftNavItems.map((item) =>
              item.active ? (
                <li key={item.name} className="flex items-center">
                  <NavLink
                    to={item.url}
                    className="text-gray-600 hover:text-blue-600 font-medium text-sm transition-colors duration-200 px-3 py-2"
                  >
                    {item.name}
                  </NavLink>
                </li>
              ) : null
            )}
          </ul>

          <SearchBar />

          <ul className="flex items-center space-x-4">
            <li className="flex items-center">
              <div
                className="relative cursor-pointer p-2"
                onClick={() => navigate("/cart")}
              >
                <ShoppingCartIcon className="h-6 w-6 text-gray-600 hover:text-blue-600 transition-colors" />
                {cartCount > 0 && (
                  <span className="absolute -top-1 -right-1 bg-blue-600 text-white text-xs font-semibold rounded-full h-5 w-5 flex items-center justify-center shadow-md">
                    {cartCount}
                  </span>
                )}
              </div>
            </li>

            {rightNavItems.map((item) =>
              item.active ? (
                <li key={item.name} className="flex items-center">
                  <NavLink
                    to={item.url}
                    className="text-gray-600 hover:text-blue-600 font-medium text-sm transition-colors duration-200 px-3 py-2"
                  >
                    {item.name}
                  </NavLink>
                </li>
              ) : null
            )}

            {authStatus && (
              <>
                <li className="flex items-center">
                  <div className="flex items-center space-x-2 cursor-pointer hover:bg-gray-50 px-3 py-2 rounded-lg transition-colors duration-200">
                    <span className="text-gray-900 font-medium text-sm">
                      {userData?.userName}
                    </span>
                    <svg
                      className="w-4 h-4 text-gray-500"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M19 9l-7 7-7-7"
                      />
                    </svg>
                  </div>
                </li>

                <li className="flex items-center h-16">
                  <div className="flex items-center h-full">
                    <LogOutBtn
                      className="inline-flex items-center justify-center 
                             px-3 py-2 
                             text-gray-600 hover:text-blue-600 
                             font-medium text-sm 
                             rounded-lg transition-colors duration-200 
                             hover:bg-gray-50
                             border-0 bg-transparent
                             leading-none"
                    />
                  </div>
                </li>
              </>
            )}
          </ul>
        </nav>
      </div>
    </header>
  )
}

export default Header