import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';

export default function Protected({ 
    children, 
    authentication = true, 
    requiredRole = null 
}) {
    const navigate = useNavigate();
    const [loader, setLoader] = useState(true);
    
    const authStatus = useSelector(state => state.auth.authStatus); // Fixed selector
    const userRole = useSelector(state => state.auth.role);

    useEffect(() => {
        if (authentication && !authStatus) {
            navigate("/login");
            return;
        }
        
        if (!authentication && authStatus) {
            navigate("/");
            return;
        }

        
        if (authentication && authStatus && requiredRole) {
            if (userRole !== requiredRole) {
                navigate("/page-not-exist");
                return;
            }
        }

        setLoader(false);
    }, [authStatus, userRole, navigate, authentication, requiredRole]);

    return loader ? <h1>Loading...</h1> : <>{children}</>;
}