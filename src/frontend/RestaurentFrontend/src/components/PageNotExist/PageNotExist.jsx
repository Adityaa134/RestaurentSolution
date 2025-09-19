import {Link} from "react-router-dom"
export default function PageNotExist() {
    return (
        <div className="flex items-center justify-center min-h-screen">
            <div className="text-center">
                
                <h2 className="text-2xl font-semibold mb-4">Page Not Exist</h2>
                <p className="text-gray-600 mb-6">
                    This type of page does not exist
                </p>
                <Link to="/" className="bg-blue-600 text-white px-4 py-2 rounded">
                    Go Home
                </Link>
            </div>
        </div>
    );
}