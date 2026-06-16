import { Link } from 'react-router-dom';
import ProductCard from '../components/ProductCard';

function Products(){
    return (
        <>
            
            <ProductCard name= "Cutlass" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            
        </>
    );
}

export default Products;