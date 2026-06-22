import styles from './ProductCard.module.css';

function ProductCard({name, price, description, quantity, seller}){
    return (
        <div className = {styles.card}>
            
                <h1 className={styles.title}>{name}</h1>
                
                {/* <img src='' alt="Iamge Placeholder" style={{height: '50px'}}/> */}
                <div className={styles.imageContainer}>
                     <div className={styles.productImage}> PLACE HOLDER FOR IMAGE</div>
                </div>
         
                <div className={styles.lowerContainer}>
                <div className={styles.priceQuantityRow}>
                    <p>Price: {price}</p>
                    <div>Stock: {quantity}</div>
                </div>
                    
                <div className={styles.sellerInfo}>
                    Sold by: {seller}
                </div>
            </div>
        </div>
    );
}
export default ProductCard;