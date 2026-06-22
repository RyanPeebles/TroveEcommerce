import { Link } from 'react-router-dom';
import ProductCard from '../components/ProductCard';
import styles from './Products.module.css';

function Products(){
    return (
        <div className = {styles.productBox}>
            
            <ProductCard name= "Cutlass" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Tricorn" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Hook hand" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cannonball" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cutlass" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Tricorn" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Hook hand" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cannonball" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cutlass" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Tricorn" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Hook hand" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cannonball" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cutlass" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Tricorn" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Hook hand" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            <ProductCard name= "Cannonball" price="$25.00" quantity= "5" description="Sharpened steel with a slight curve for a clean slice" seller = 'East India Trade Co.'></ProductCard>
            
        </div>
    );
}

export default Products;