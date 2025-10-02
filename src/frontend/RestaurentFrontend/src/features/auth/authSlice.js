import { createSlice } from "@reduxjs/toolkit"

const initialState = {
    authStatus: false,
    userData: null,
    token: null,
    role:null
}

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        login: (state, action) => {
            state.authStatus = true;
            state.userData = action.payload.user
            state.token = action.payload.token;
            state.role = action.payload.role
        },
        logout: (state, action) => {
            state.authStatus = false,
            state.userData = action.payload
            state.token = action.payload;
            state.role = null
        }
    }
})

export const { login, logout } = authSlice.actions

export default authSlice.reducer