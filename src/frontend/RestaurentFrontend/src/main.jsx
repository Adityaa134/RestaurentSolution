import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import { Provider } from "react-redux"
import { RouterProvider } from "react-router-dom"
import store from "./store/store.js"
import { createBrowserRouter } from 'react-router-dom'
import Home from './pages/Home.jsx'
import Login from './pages/Login.jsx'
import Register from './pages/Register.jsx'
import AddDish from './pages/AddDish.jsx'
import ConfirmEmail from "./pages/ConfirmEmail.jsx"
import ConfirmEmailSuccess from './pages/ConfirmEmailSuccess.jsx'
import DishDetails from "./pages/DishDetails.jsx"
import EditDish from "./pages/EditDish.jsx"
import PageNotExist from "./pages/PageNotExist.jsx"
import {Protected} from "./components/index.js"
import Categories from "./pages/Categories.jsx"
import ForgotPassword from "./pages/ForgotPassword.jsx"
import ResetPassword from "./pages/ResetPassword.jsx"
import Cart from "./pages/Cart.jsx"


const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "/",
        element: <Home />
      },
      {
        path: "/categories",
        element: <Categories />
      },
      {
        path: "/login",
        element: (
          <Protected authentication={false}>
             < Login />
          </Protected>
        )
      },
      {
        path: "/register",
        element: (
          <Protected authentication={false}>
             < Register />
          </Protected>
        )
      },
      {
        path: "/add-dish",
        element: (
          <Protected requiredRole="admin">
             < AddDish />
          </Protected>
        )
      },
      {
        path: "/confirm-email",
        element: <ConfirmEmail />
      },
      {
        path: "/confirm-email-success",
        element: <ConfirmEmailSuccess />
      },
      {
        path: "/dish/:dishId",
        element: < DishDetails />
      },
      {
        path: "/edit-dish/:dishId",
        element: (
          <Protected requiredRole="admin">
             < EditDish />
          </Protected>
        )
      },
      {
        path: "/page-not-exist",
        element: < PageNotExist />
      },
      {
        path: "/forgot-password",
        element: < ForgotPassword />
      },
      {
        path: "/reset-password",
        element: < ResetPassword />
      },
      {
        path: "/cart",
        element: < Cart />
      }
    ]
  }
])



createRoot(document.getElementById('root')).render(

  <Provider store={store}>
    <RouterProvider router={router} />
  </Provider>

)
