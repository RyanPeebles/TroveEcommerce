import { Link } from 'react-router-dom';

function LandingPage() {
    return (
        <div style={{textAlign: 'center', padding: '50px'}}>
            <h1>Welcome to Trove Ecommerce</h1>
            <p>The best deals on the Seven Seas!</p>

            <Link to="/products" style={{ fontSize: '18px', color: '#007bff'}}>
                Browse Products
            </Link>
        </div>
    );
}

export default LandingPage;